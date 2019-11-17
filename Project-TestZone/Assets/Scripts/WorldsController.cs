using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Testzone
{
	public class WorldsController : MonoBehaviour
	{
		[SerializeField]
		private GameObject PlayerObject;
		[SerializeField]
		private GameObject PlatformsWorld1;
		[SerializeField]
		private GameObject PlatformsWorld2;

		private PlayerInput Input;

		public int PlayerCurrentWorld = 1; 

		void Awake()
		{
			Input = PlayerObject.GetComponent<PlayerInput>();
		}

		void FixedUpdate()
		{
			if (Input.SwitchPressed)
			{
				SwitchPlayerWorld();
				ToggleRenderers(PlayerCurrentWorld);
			}
		}

		void SwitchPlayerWorld()
		{
			// TODO:
			// - Add logic to make sure the player can't switch worlds if their position in the other world is inside a wall, or things like that.
			// - Add a cooldown so the player can't repeatedly switch worlds too fast

			PlayerCurrentWorld *= -1;
			
			// 2->1
			if (PlayerCurrentWorld > 0)
			{
				PlayerObject.layer = (int)Layers.PLAYERW1;

				// Need to inform the movement controller script that the ground is now world 1's ground
				var movementController = PlayerObject.GetComponent<PlayerMovement>();
				movementController.groundLayer = LayerMask.GetMask("Platforms1");
			}
			// 1->2
			else
			{
				PlayerObject.layer = (int)Layers.PLAYERW2;

				var movementController = PlayerObject.GetComponent<PlayerMovement>();
				movementController.groundLayer = LayerMask.GetMask("Platforms2");
			}
		}

		void ToggleRenderers(int newWorld)
		{
			var world1renderer = PlatformsWorld1.GetComponent<Renderer>();
			var world2renderer = PlatformsWorld2.GetComponent<Renderer>();

			// Going from 2 to 1.
			if (newWorld > 0)
			{
				world1renderer.enabled = true;
				world2renderer.enabled = false;

				// have to go in and enable renderers of all objs in layer Objects1, disable of all in Objects2
			}
			// Going from 1 to 2.
			else
			{
				world1renderer.enabled = false;
				world2renderer.enabled = true;
				
				// converse of the other case
			}
		}

	}

}