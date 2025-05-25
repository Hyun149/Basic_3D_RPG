/// <summary>
/// 오브젝트 풀로부터 생성되거나 반환될 때 호출되는 인터페이스입니다.
/// </summary>
public interface IPoolable
{
    void OnSpawn();
    void OnDespawn();
}
