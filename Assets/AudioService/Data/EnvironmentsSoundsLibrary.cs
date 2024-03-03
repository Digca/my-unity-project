using UnityEngine;


namespace TaxiManiac
{
    [CreateAssetMenu(fileName = "TrapsSoundLibrary", menuName = "Sound system/New Traps Sound Library", order = 1)]
    public class EnvironmentsSoundsLibrary : ScriptableObject
	{
		[SerializeField] private AudioClip fireDoorMoveSound = default;
        [SerializeField] private AudioClip elevatorDoorMoveSound = default;
		[SerializeField] private AudioClip fanWorkSound = default;
		[SerializeField] private AudioClip laserWorkSound = default;
        [SerializeField] private AudioClip tossJumpSound = default;

		[Space(10), Header("Hockey goal")]
		[SerializeField] private AudioClip hockeyGoalSound = default;

		[Space(10), Header("Metropolitan")]
		[SerializeField] private AudioClip metroTrainAppear = default;
		[SerializeField] private AudioClip metroTrainMove = default;

		[Space(10), Header("Trucks")]
		[SerializeField] private AudioClip truckMovementSound = default;
		[SerializeField] private AudioClip trucksClashSound = default;

		[Space(10), Header("Space station")]
		[SerializeField] private AudioClip teleportSound = default;

		[Space(10), Header("School Class")]
		[SerializeField] private AudioClip glassBreak = default;


        public AudioClip FireDoorMoveSound => fireDoorMoveSound;
		public AudioClip ElevatorDoorMoveSound => elevatorDoorMoveSound;
		public AudioClip FanWorkSound => fanWorkSound;
		public AudioClip LaserWorkSound => laserWorkSound;
        public AudioClip TossJumpSound => tossJumpSound;
		public AudioClip HockeyGoalSound => hockeyGoalSound;
		public AudioClip MetroTrainAppear => metroTrainAppear;
		public AudioClip MetroTrainMove => metroTrainMove;
		public AudioClip TruckMovementSound => truckMovementSound;
		public AudioClip TrucksClashSound => trucksClashSound;
		public AudioClip TeleportSound => teleportSound;
		public AudioClip GlassBreak => glassBreak;
	}
}
