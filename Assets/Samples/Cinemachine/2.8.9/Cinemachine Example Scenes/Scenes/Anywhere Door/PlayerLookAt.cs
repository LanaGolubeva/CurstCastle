﻿using UnityEngine;

namespace Samples.Cinemachine._2._8._9.Cinemachine_Example_Scenes.Scenes.Anywhere_Door
{
	public class PlayerLookAt : MonoBehaviour
	{
		public float speed = 5f;

		void Update()
		{
		
			float horizontal = Input.GetAxis("Mouse X") * speed;
			float vertical = Input.GetAxis("Mouse Y") * speed;

			transform.Rotate(0f, horizontal, 0f, Space.World);
			transform.Rotate(-vertical, 0f, 0f, Space.Self);

		}
	}
}