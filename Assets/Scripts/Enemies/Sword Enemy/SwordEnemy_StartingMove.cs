using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy_StartingMove : SwordEnemyState
{
    private SwordEnemy.State nextState;
    private Vector2 playerPosition; // Updated each frame
    private float verticalTolerance = 1.5f;
    private float followDistance = 10.0f;
    private int moveDirection = 1;
    private bool hasObstacle = false; // TODO: Update later
    private bool hasTurned = false; // TODO: Update later
    
    public SwordEnemy_StartingMove(SwordEnemy.State key, GameObject _swordEnemyGameObject, GameObject _playerGameObject) : base(key, _swordEnemyGameObject, _playerGameObject)
    {
    }

    public override void EnterState()
    {
        nextState = SwordEnemy.State.STATE_STARTINGMOVE;
        swordEnemyComponent.ChangeAnimationState("StartingMove");
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
        playerPosition = playerGameObject.transform.position;
        checkPlayer();
        
        float moveDirectionX = moveDirection;
        float step = swordEnemyComponent.movementSpeed * moveDirectionX;
        swordEnemyRigidbody.velocity = new Vector3(step, swordEnemyRigidbody.velocity.y);
    }

    void checkPlayer()
    {
        Vector3 enemyPosition = new Vector2(swordEnemyRigidbody.position.x, swordEnemyRigidbody.position.y); // Düşmanın konumu
        float distanceToPlayer = Vector2.Distance(enemyPosition, playerPosition);
        
        bool isBetweenWalls = swordEnemyComponent.transform.position.x >= swordEnemyComponent.leftWall.transform.position.x &&
                              swordEnemyComponent.transform.position.x <= swordEnemyComponent.rightWall.transform.position.x;

        if (distanceToPlayer < followDistance && Mathf.Abs(enemyPosition.y - playerPosition.y) < verticalTolerance && !hasObstacle)
        {
            hasTurned = false;
            if (distanceToPlayer <= 3f)
            {
                nextState = SwordEnemy.State.STATE_WAIT;
            }
            else
            {
                nextState = SwordEnemy.State.STATE_FOLLOWING;
            }
        }
        else if (isBetweenWalls)
        {
            // check = false;
            hasObstacle = false;
        }
        else
        {
            nextState = SwordEnemy.State.STATE_BACKTOWALL;
        }
            
    }
    
    public override SwordEnemy.State GetNextState()
    {
        return nextState;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall"))
        {
            moveRight = !moveRight;
            moveDirection *= -1;
            swordEnemyComponent.transform.Rotate(0f, 180f, 0f);
        }
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
    }
}
