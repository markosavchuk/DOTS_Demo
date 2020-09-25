using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : SingletonMonoBehaviour<Initialization>
{
    [SerializeField]
    private GameObject _builingPrefab;

    [SerializeField]
    private int _squareSize;

    [SerializeField]
    private int _numberOfCharacters;

    [SerializeField]
    private List<GameObject> CharacterCollection;

    public List<Vector3> AvailablePositions;

    private int _halfOfSquere;

    private void Awake()
    {
        _halfOfSquere = (int) _squareSize / 2;
        AvailablePositions = new List<Vector3>();

        GenerateLevel();
        AddCharacters();
    }

    private void GenerateLevel()
    {
        for (int x = -_halfOfSquere; x <= _halfOfSquere; x+=2)
        {
            for (int z = -_halfOfSquere; z <= _halfOfSquere; z+=2)
            {
                if (Random.value > .89f ||
                   x == -_halfOfSquere || x == _halfOfSquere || z == -_halfOfSquere || z == _halfOfSquere)
                {
                    var position = new Vector3(x, 0.5f, z);
                    Instantiate(_builingPrefab, position, Quaternion.identity, transform);
                }
                else
                {
                    AvailablePositions.Add(new Vector3(x, 0, z));
                }
            }
        }
    }

    private void AddCharacters()
    {
        var positionsToInit = new List<Vector3>(AvailablePositions);

        for (int i = 0; i < _numberOfCharacters; i++)
        {
            var position = positionsToInit[Random.Range(0, positionsToInit.Count)];
            var characterPrefab = CharacterCollection[Random.Range(0, CharacterCollection.Count - 1)];
            Instantiate(characterPrefab, position, Quaternion.identity, transform);
        }
    }
}
