using UnityEngine;

public class ImageEffectBloom : ImageEffectBase
{
	private const int thresholdPass = 0;
	private const int horizontalPass = 1;
	private const int verticalPass = 2;
	private const int bloomPass = 3;

	protected override void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		RenderTexture thresholdTex = RenderTexture.GetTemporary(src.width, src.height, 0, src.format);
		Graphics.Blit(src, thresholdTex, material, thresholdPass);

		RenderTexture blurTex = RenderTexture.GetTemporary(src.width, src.height, 0, src.format);
		RenderTexture temp = RenderTexture.GetTemporary(src.width, src.height, 0, src.format);

		Graphics.Blit(thresholdTex, temp, material, horizontalPass);
		Graphics.Blit(temp, blurTex, material, verticalPass);

		RenderTexture.ReleaseTemporary(thresholdTex);
		RenderTexture.ReleaseTemporary(temp);

		material.SetTexture("_SrcTex", src);
		Graphics.Blit(blurTex, dst, material, bloomPass);

		RenderTexture.ReleaseTemporary(blurTex);
	}
}
