using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Step03
{

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem ps;
    public int exp1_;
    public int exp2_;
    bool bExp;

    IEnumerator Co_LevelUp()
    {
        ParticleSystem _ps = Instantiate(ps , transform.position , Quaternion.identity) as ParticleSystem;
        _ps.Stop();
        _ps.Play();

        float _duration = 2f;
        float _speed = 1f / _duration;
        float _percent = 0;

        Material _mat = GetComponent<MeshRenderer>().material;
        while (_percent < 1f)
        {
            _percent += _speed * Time.deltaTime;
            _mat.color = Color.Lerp(Color.white, Color.red, _percent);
            Debug.Log(_percent);

            yield return null;
        } 
        _mat.color = Color.white;
        /**/
    }

    public int exp{
        get { return exp1_ + exp2_; }
        set {
            int _v1 = level;
            if (bExp)exp1_ += ( value - exp);
            else exp2_ += ( value - exp );
            bExp = !bExp;
            int _v2 = level;
            if(_v1 != _v2)
            {
                StopCoroutine("Co_LevelUp");
                StartCoroutine("Co_LevelUp");
            }
        }
    }
    public int level
    {
        get
        {
            return exp / 10 + 1;
        }
    }


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // 몬스터
                exp = exp + 1; 
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // 대화중
                exp = exp + 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                // 보스전 잡몹
                exp += 3;
            }

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                // 보스전 잡몹
                Debug.Log(exp);
            }
        }
        
    }

}