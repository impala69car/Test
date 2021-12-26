using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.ShipControllers.CustomControllers;
using DG.Tweening;
using UnityEngine;

public class EnemyShipController : ShipController
{
    [SerializeField]
    private Vector2 _fireDelay;

    private bool _fire = true;
    protected int anotherMovement = 0;
    protected PlayerShipController shipController;
    public void SetController(PlayerShipController _ship)
    {
        shipController = _ship;
    }
    public void setAnotherMovement(int any)
    {
        anotherMovement = any;
    }
    float mag;
    protected override void ProcessHandling(MovementSystem movementSystem)
    {
        //if (anotherMovement == 1) { movementSystem.LateralMovement(Time.deltaTime); }
        //else if (anotherMovement == -1) { movementSystem.HorizontalMovement(Time.deltaTime); }
        //else if (anotherMovement == -2) { }
        //else { movementSystem.LongitudinalMovement(Time.deltaTime); }
        //movementSystem.moveToPlayer(shipController.transform.position, Time.deltaTime);
        mag = (transform.position - shipController.transform.position).magnitude;
        //transform.DOMove(shipController.transform.position, 25f);
        movementSystem.moveToPlayer(Vector3.MoveTowards(transform.position, shipController.transform.position, mag > 2f ? 7 * UnityEngine.Time.deltaTime : Mathf.Lerp(7 * 0.5f, 7, mag / 2f) * UnityEngine.Time.deltaTime));
    }
    protected override void ProcessFire(WeaponSystem fireSystem)
    {
        if (!_fire)
            return;

        fireSystem.TriggerFire();
        StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
    }


    private IEnumerator FireDelay(float delay)
    {
        _fire = false;
        yield return new WaitForSeconds(delay);
        _fire = true;
    }
}
