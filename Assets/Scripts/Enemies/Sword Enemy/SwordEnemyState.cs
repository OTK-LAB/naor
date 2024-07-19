using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwordEnemyState : BaseState<SwordEnemy.State>
{
    protected GameObject playerGameObject;
    protected GameObject swordEnemyGameObject;
    protected SwordEnemy swordEnemyComponent;
    protected Rigidbody2D swordEnemyRigidbody;
    protected bool moveRight = false;

    public SwordEnemyState(SwordEnemy.State key, GameObject _swordEnemyGameObject, GameObject _playerGameObject) : base(key)
    {
        swordEnemyGameObject = _swordEnemyGameObject;
        playerGameObject = _playerGameObject;

        swordEnemyComponent = swordEnemyGameObject.GetComponent<SwordEnemy>();
        swordEnemyRigidbody = swordEnemyGameObject.GetComponent<Rigidbody2D>();
    }
}
