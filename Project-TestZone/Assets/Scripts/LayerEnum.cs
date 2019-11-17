using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Testzone
{
	// User defined layers in Unity start from 8.
	// Don't forget to cast to int before use.
	enum Layers
	{
		BG1 = 8,
		BG2,
		PLATFORMS1,
		PLATFORMS2,
		OBJECTS1,
		OBJECTS2,
		OBJECTS_PERSISTENT,
		PLAYERW1,
		PLAYERW2
	};
}