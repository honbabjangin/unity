using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Step03
{
    
    public class CoTest2 : MonoBehaviour
    {
        public float speed = 2f;
        public Transform target;
        Camera camera;
        public LayerMask mask;

        public Coroutine coroutine;

        void Start()
        {
            camera = Camera.main;
            
        }
        void Update()
        {
            Debug.Log(" Update ");
            
            if(Input.GetMouseButtonDown(0))
            {
                Ray _ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit _hit;
                // Debug.DrawRay(_ray.origin, _ray.direction*10, Color.green);
                if(Physics.Raycast(_ray, out _hit, 20f, mask))
                {
                    // Debug.Log(">>>" + _hit.collider.name);
                    if (coroutine != null) StopCoroutine("Co_MoveToward");
                    coroutine = StartCoroutine(Co_MoveToward(_hit.point, 0.000001f));
                }
            }
        }

        IEnumerator Co_MoveToward(Vector3 _point, float _limit)
        {
            // while(타켓지점 != 히트지점에 도착했냐? ?)
            // {
            //     히트 지점 으로 타겟 이동시켜줘라!!
            // }
            while(Vector3.Distance(target.position, _point) > _limit)
            {
                Debug.Log("CoMove");
                target.position = Vector3.MoveTowards(target.position, _point, speed * Time.deltaTime);
                yield return null;
            }
            Debug.Log(" End ");
        }
    }
}