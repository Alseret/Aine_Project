using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(SkewedImage), true)]
[CanEditMultipleObjects]
public class SkewedImageEditor : ImageEditor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		var targetSkewedImage = this.target as SkewedImage;
		if (targetSkewedImage != null)
		{
			var prevSkew = targetSkewedImage.Skew;
			var newSkew = EditorGUILayout.Vector2Field("Skew", prevSkew);
			var dirty = false;
			if (newSkew != prevSkew)
			{
				targetSkewedImage.Skew = newSkew;
				dirty = true;
			}
			var prevSliceOffsetV = targetSkewedImage.SliceOffsetV;
			var newSliceOffsetV = EditorGUILayout.Vector2Field("Vertical Slice Offset", prevSliceOffsetV);
			if (newSliceOffsetV != prevSliceOffsetV)
			{
				targetSkewedImage.SliceOffsetV = newSliceOffsetV;
				dirty = true;
			}
			if (dirty)
			{
				targetSkewedImage.SetVerticesDirty();
			}
		}
	}
}