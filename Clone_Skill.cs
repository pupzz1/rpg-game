using System.Collections;
using UnityEngine;

public class Clone_Skill : Skill
{

    [Header("Clone info")]
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDuration;
    [Space]
    [SerializeField] private bool canAttack;

    [SerializeField] private bool createCloneOnDashStart;
    [SerializeField] private bool creatCloneOnDashOver;
    [SerializeField] private bool canCreatCloneOnCounterAttack;
    [Header("Clone can duplicate")]
    [SerializeField] private bool canDuplicateClone;
    [SerializeField] private float chanceDuplicate;
    [Header("Crystal instead of clone")]
    [SerializeField] public bool crystalInseadOfClone;
    public void CreatClone(Transform _clonePosition, Vector3 _offset)
    {
        if (crystalInseadOfClone)
        {
            SkillManger.instance.crystal.CreateCrystal();
            return;
        }

        GameObject newClone = Instantiate(clonePrefab);

        newClone.GetComponent<Clone_Skill_Controller>().
            SetupClone(_clonePosition, cloneDuration, canAttack, _offset, FindClosestEnemy(newClone.transform),canDuplicateClone,chanceDuplicate,player);
    }

    public void CreatCloneOnDashStart()
    {
        if (createCloneOnDashStart)
            CreatClone(player.transform, Vector3.zero);
    }

    public void CreatCloneOnDashOver()
    {
        if (creatCloneOnDashOver)
            CreatClone(player.transform, Vector3.zero);
    }

    public void CreatCloneOnCounterAttack(Transform _enemyTransform)
    {
        if (canCreatCloneOnCounterAttack)
            StartCoroutine(CreatCloneWithDelay(_enemyTransform, new Vector3(1 * player.facingDir, 0)));
    }

    private IEnumerator CreatCloneWithDelay(Transform _transform,Vector3 _offset)
    {
        yield return new WaitForSeconds(.4f);
            CreatClone(_transform, _offset);
    }
}
