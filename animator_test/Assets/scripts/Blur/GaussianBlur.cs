using UnityEngine;
using System.Collections;

public class GaussianBlur : MonoBehaviour
{
    // ガウスフィルタマテリアル
    public Material m_material;

    private const float DISPERSION = 5.0f;  // ガウス散乱率
    private const int SAMPLING_NUM = 8;     // サンプリング数

    // 重み格納配列(値をインスペクタで確認したいので、public)
    public float[] m_gaussWeight;

    void Start()
    {
        // 重み計算
        {
            m_gaussWeight = new float[SAMPLING_NUM];
            float total = 0.0f;
            for (int i = 0; i < SAMPLING_NUM; ++i)
            {
                float weight = Mathf.Exp(-0.5f * (i * i) / (DISPERSION * DISPERSION));
                total += 2.0f * weight;
                m_gaussWeight[i] = weight;
            }
            for (int i = 0; i < SAMPLING_NUM; ++i) m_gaussWeight[i] /= total;
        }

        // 重み配列をシェーダへ渡す
        {
            if (m_material != null)
            {
                Vector4 v4 = new Vector4();
                v4.Set(m_gaussWeight[0], m_gaussWeight[1], m_gaussWeight[2], m_gaussWeight[3]);
                m_material.SetVector("_GaussParam0", v4);
                v4.Set(m_gaussWeight[4], m_gaussWeight[5], m_gaussWeight[6], m_gaussWeight[7]);
                m_material.SetVector("_GaussParam1", v4);
            }
        }
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        // ガウスフィルタをかけて描画
        if (m_material != null)
        {
            Graphics.Blit(src, dst, m_material);
        }
    }
}