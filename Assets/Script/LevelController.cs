using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    private static int _nextLevelIndex = 1;

    //Get call when it's enable
    private void OnEnable()
    {
        //save all enemies 
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if(enemy!= null)
            {
                return;
            }

            _nextLevelIndex++;
            string nextLevelName = "Level" + _nextLevelIndex;

            SceneManager.LoadScene(nextLevelName);
        }
    }
}
