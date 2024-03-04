using UnityEngine;
using VContainer.Unity;

namespace Core
{
	public abstract class Character : MonoBehaviour, IStartable
	{
		[SerializeField] protected Rigidbody _rb;
		[SerializeField] protected Animator _anim;

		public virtual void Start() { }
	}
}
