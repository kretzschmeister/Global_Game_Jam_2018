/* This is a simple static class,
 * this class is used for variables in the game
 * Like keys, gems, lives, ammo
 * but also thinks like active powerups.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariables {

	public static int keyCount = 0;
	public static int gemCount = 0;
	public static int lives = 3;
    public static float signalSwitcherPoints = 100;

}
