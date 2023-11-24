public enum EnemyState
{
    Patrolling,                 // Default State. Patrols around a pre-defined path
    Chasing,                    // Player got in view of enemy. Enemy is chasing the player
    Hunting,                    // Player is not in cage on time. Enemy is hunting the player down
    Catching                    // Enemy is currently catching the player
}
