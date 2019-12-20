using UnityEngine;
using UnityEditor;

public class SpritePostProcessor : AssetPostprocessor
{
    private int PPU = 16;
    

	void OnPreprocessTexture ()
	{
		TextureImporter textureImporter  = (TextureImporter) assetImporter;

		TextureImporterSettings tis = new TextureImporterSettings ();
		textureImporter.ReadTextureSettings (tis);

		tis.spritePixelsPerUnit = PPU;
        tis.filterMode = FilterMode.Point;
        tis.mipmapEnabled = false; 
        tis.wrapMode = TextureWrapMode.Clamp;

		textureImporter.SetTextureSettings (tis);
	}

}