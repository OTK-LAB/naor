using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_Dead : ArcherState
{
    private Collider2D _collider2D;
    private SpriteRenderer _spriteRenderer;
    
    public Archer_Dead(GameObject _archerGameObject, GameObject _playerGameObject) : base(Archer.State.STATE_DEAD, _archerGameObject, _playerGameObject)
    {
        _collider2D = _archerGameObject.GetComponent<Collider2D>();
        _spriteRenderer = archerGameObject.GetComponent<SpriteRenderer>();
    }

    public override void EnterState()
    {
        archerComponent.ChangeAnimationState(ArcherAnimNames.death);
        
        archerRigidBody.bodyType = RigidbodyType2D.Kinematic;
        _collider2D.enabled = false;
        _spriteRenderer.sortingLayerName = "Foreground";
    }

    public override void ExitState()
    {}

    public override void UpdateState()
    {}

    public override Archer.State GetNextState()
    {
        return Archer.State.STATE_DEAD;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {}

    public override void OnTriggerStay2D(Collider2D other)
    {}

    public override void OnTriggerExit2D(Collider2D other)
    {}
}
