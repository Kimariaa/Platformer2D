using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Supporting;
using System;

namespace Player
{
    public class PlayerFiring
    {
        private float _fireTimer, _fireDelay;
        private ObjectPool _objectPool;
        private GameObject _bullet;

        public PlayerFiring(float fireDelay, int bulletAmount, GameObject bulletPrefab)
        {
            _fireDelay = fireDelay;
            _fireTimer = _fireDelay;

            _objectPool = new ObjectPool(bulletAmount, bulletPrefab);
        }

        public void TryFiring(float deltaTime, bool firing, Vector3 firePosition, bool direction)
        {
            if (_fireTimer > 0)
            {
                _fireTimer -= deltaTime;
            }
            else if (firing)
            {
                _bullet = _objectPool.GetObject();

                if (_bullet != null)
                {
                    Wisp wisp = _bullet.TryGetComponent(out Wisp projectile) ? projectile : throw new NullReferenceException("Projectile have no Wisp component");

                    wisp.Init(firePosition, direction);

                    _fireTimer = _fireDelay;
                }

            }
        }

    }

}
