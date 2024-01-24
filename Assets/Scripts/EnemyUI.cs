using System.Collections;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Material _usualMaterial;
    [SerializeField] private Material _onDamagedMaterial;

    private Enemy _enemy;
    private MeshRenderer _enemyRenderer;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _enemyRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _enemy.OnDamaged += OnDamaged;
    }

    private void OnDamaged()
    {
        _enemyRenderer.material = _onDamagedMaterial;
        StartCoroutine(ChangeMaterialBack());
    }

    private IEnumerator ChangeMaterialBack()
    {
        yield return new WaitForSeconds(.1f);
        _enemyRenderer.material = _usualMaterial;
    }
}
