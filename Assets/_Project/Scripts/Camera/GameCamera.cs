using UnityEngine;

namespace RoundsTextAdventure
{
	[RequireComponent(typeof(Camera))]
	public class GameCamera : MonoBehaviourServiceUser
	{
		private Camera theCamera;
		private float cameraHalfWidth;
		private float cameraHalfHeight;
		private float halfScreenWidth;
		private float halfScreenHeight;

		public void Initialise()
		{
			theCamera = gameObject.GetComponent<Camera>();
			cameraHalfHeight = theCamera.orthographicSize;
			cameraHalfWidth = theCamera.aspect * cameraHalfHeight;
			halfScreenWidth = Screen.width * 0.5f;
			halfScreenHeight = Screen.height * 0.5f;
		}
		
		public Vector3 ScreenPositionToWorldPosition(Vector2 screenPosition)
		{
			return new Vector3(
				(screenPosition.x - halfScreenWidth) / halfScreenWidth * cameraHalfWidth,
				(screenPosition.y - halfScreenHeight) / halfScreenHeight * cameraHalfHeight,
				0.0f
			);
		}
		
		public Vector2 WorldPositionToScreenPosition(Vector3 worldPosition)
		{
			return new Vector2(
				(worldPosition.x / cameraHalfWidth) * halfScreenWidth + halfScreenWidth,
				(worldPosition.y / cameraHalfHeight) * halfScreenHeight + halfScreenHeight
			);
		}
	}
}
