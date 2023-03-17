using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    #region Variable Organization Classes
    [System.Serializable]
    public class WalkVariables
    {
        [SerializeField] private float physics2DGravityScale;
        [SerializeField] private float maxSpeed;
        [SerializeField, BoundedCurve, Space(5)] private AnimationCurve speedUpCurve;
        [SerializeField] private float speedUpTime;
        [SerializeField, BoundedCurve, Space(5)] private AnimationCurve slowDownCurve;
        [SerializeField] private float slowDownTime;

        public float Physics2DGravityScale => physics2DGravityScale;
        public float MaxSpeed => maxSpeed;
        public AnimationCurve SpeedUpCurve => speedUpCurve;
        public float SpeedUpTime => speedUpTime;
        public AnimationCurve SlowDownCurve => slowDownCurve;
        public float SlowDownTime => slowDownTime;
    }
    [System.Serializable]
    public class CrouchVariables
    {
        [SerializeField] private float physics2DGravityScale;
        [SerializeField] private float maxSpeed;
        [SerializeField, BoundedCurve, Space(5)] private AnimationCurve speedUpCurve;
        [SerializeField] private float speedUpTime;
        [SerializeField, BoundedCurve, Space(5)] private AnimationCurve slowDownCurve;
        [SerializeField] private float slowDownTime;

        public float Physics2DGravityScale => physics2DGravityScale;
        public float MaxSpeed => maxSpeed;
        public AnimationCurve SpeedUpCurve => speedUpCurve;
        public float SpeedUpTime => speedUpTime;
        public AnimationCurve SlowDownCurve => slowDownCurve;
        public float SlowDownTime => slowDownTime;
    }
    [System.Serializable]
    public class JumpVariables
    {
        [SerializeField] private float maxHeight;
        [SerializeField, BoundedCurve] private AnimationCurve jumpHeightCurve;
        [SerializeField] private float jumpTime;
        [SerializeField, NonEditable] private AnimationCurve jumpVelocityCurve;
        [SerializeField, Range(0, 1)] private float jumpCutPower;
        [SerializeField, Range(0, 0.5f)] private float coyoteTimeMaxTime, jumpBufferMaxTime;
        [SerializeField, NonEditable] private float coyoteTimeTimer, jumpBufferTimer;
        [SerializeField, NonEditable] private float physics2DGravityScale = 0f;
        [SerializeField] private float maxXSpeed;
        [SerializeField, BoundedCurve, Space(5)] private AnimationCurve xSpeedUpCurve;
        [SerializeField] private float xSpeedUpTime;
        [SerializeField, BoundedCurve, Space(5)] private AnimationCurve xSlowDownCurve;
        [SerializeField] private float xSlowDownTime;

        public float MaxHeight => maxHeight;
        public AnimationCurve JumpHeightCurve => jumpHeightCurve;
        public float JumpTime => jumpTime;
        public AnimationCurve JumpVelocityCurve { get { return jumpVelocityCurve; } set{ jumpVelocityCurve = value;} }
        public float JumpCutPower => jumpCutPower;
        public float CoyoteTimeMaxTime => coyoteTimeMaxTime;
        public float JumpBufferMaxTime => jumpBufferMaxTime;
        public float CoyoteTimeTimer { get { return coyoteTimeTimer; } set { coyoteTimeTimer = value; } }
        public float JumpBufferTimer { get { return jumpBufferTimer; } set { jumpBufferTimer = value; } }
        public float Physics2DGravityScale => physics2DGravityScale;
        public float XMaxSpeed => maxXSpeed;
        public AnimationCurve XSpeedUpCurve => xSpeedUpCurve;
        public float XSpeedUpTime => xSpeedUpTime;
        public AnimationCurve XSlowDownCurve => xSlowDownCurve;
        public float XSlowDownTime => xSlowDownTime;

    }
    [System.Serializable]
    public class LandVariables
    {
        [SerializeField, BoundedCurve] private AnimationCurve landHeightCurve;
        [SerializeField] private float landTime;
        [SerializeField, NonEditable] private AnimationCurve landVelocityCurve;
        [SerializeField] private float minLandSpeed;
        [SerializeField, NonEditable] private float physics2DGravityScale = 0f;
        [SerializeField] private float maxXSpeed;
        [SerializeField, BoundedCurve, Space(5)] private AnimationCurve xSpeedUpCurve;
        [SerializeField] private float xSpeedUpTime;
        [SerializeField, BoundedCurve, Space(5)] private AnimationCurve xSlowDownCurve;
        [SerializeField] private float xSlowDownTime;

        public AnimationCurve LandHeightCurve => landHeightCurve;
        public float LandTime => landTime;
        public AnimationCurve LandVelocityCurve { get { return landVelocityCurve; } set { landVelocityCurve = value; } }
        public float MinLandSpeed => minLandSpeed;
        public float Physics2DGravityScale => physics2DGravityScale;
        public float MaxXSpeed => maxXSpeed;
        public AnimationCurve XSpeedUpCurve => xSpeedUpCurve;
        public float XSpeedUpTime => xSpeedUpTime;
        public AnimationCurve XSlowDownCurve => xSlowDownCurve;
        public float XSlowDownTime => xSlowDownTime;
    }
    [System.Serializable]
    public class DashVariables
    {
        [SerializeField, Space(5)] private float maxHeight;
        [SerializeField, BoundedCurve(0,-1,1,2)] private AnimationCurve dashHeightCurve;
        [SerializeField, NonEditable] private AnimationCurve dashYVelovityCurve;
        [SerializeField, Space(5)] private float maxSpeed;
        [SerializeField, BoundedCurve] private AnimationCurve dashXVelocityCurve;
        [SerializeField, Space(5)] private float dashTime;
        [SerializeField, NonEditable] private float physics2DGravityScale = 0f;

        public float MaxHeight => maxHeight;
        public AnimationCurve DashHeightCurve => dashHeightCurve;
        public AnimationCurve DashYVelocityCurve { get { return dashYVelovityCurve; } set { dashYVelovityCurve = value; } }
        public float MaxSpeed => maxSpeed;
        public AnimationCurve DashXVelocityCurve => dashXVelocityCurve;
        public float DashTime => dashTime;
        public float Physics2DGravityScale => physics2DGravityScale;
    }
    [System.Serializable]
    public class CheckVariables
    {
        [SerializeField, NonEditable] private Vector3 groundCheckPosition;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField, NonEditable] private bool isGrounded, isOnSlope;
        private bool canJump, cutJump;
        [SerializeField] private float maxSlopeAngle;
        [SerializeField, NonEditable] private float currentSlopeAngle;
        [SerializeField, NonEditable] private Vector2 onSlopeSpeedDirection;
        [SerializeField] private List<ContactPoint2D> colliderContacs = new();
        [SerializeField, NonEditable] private bool isOnMovableSlope;
        [SerializeField, NonEditable] private Vector2 slopeContactPosition;

        public Vector3 GroundCheckPosition { get { return groundCheckPosition; } set { groundCheckPosition = value; } }
        public LayerMask GroundLayer => groundLayer;
        public bool IsGrounded { get { return isGrounded; } set { isGrounded = value; } }
        public bool IsOnSlope { get { return isOnSlope; } set{ isOnSlope = value; } }
        public bool CanJump { get { return canJump; } set { canJump = value; } }
        public bool CutJump { get { return cutJump; } set { cutJump = value; } }
        public float MaxSlopeAngle => maxSlopeAngle;
        public float CurrentSlopeAngle { get { return currentSlopeAngle; } set { currentSlopeAngle = value; } }
        public Vector2 OnSlopeSpeedDirection { get { return onSlopeSpeedDirection; } set { onSlopeSpeedDirection = value; } }
        public List<ContactPoint2D> ColliderContacs { get { return colliderContacs; } set { colliderContacs = value; } }
        public bool IsOnMovableSlope { get { return isOnMovableSlope; } set { isOnMovableSlope = value; } }
        public Vector2 SlopeContactPosition { get { return slopeContactPosition; } set { slopeContactPosition = value; } }
    }

    [System.Serializable]
    public class MaterialVariables
    {
        [SerializeField] private PhysicsMaterial2D zeroFriction;
        [SerializeField] private PhysicsMaterial2D infFriction;
        public PhysicsMaterial2D ZeroFriction => zeroFriction;
        public PhysicsMaterial2D InfFriction => infFriction;
    }
    #endregion

    [Space(7)]
    public WalkVariables Walk;
    public CrouchVariables Crouch;
    public JumpVariables Jump;
    public LandVariables Land;
    public DashVariables Dash;
    public CheckVariables Check;
    public MaterialVariables Material;
}