using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class TagsContainer : MonoBehaviour
    {
        [SerializeField] private List<string> customTags = new();

        public bool HasTag(string customTag)
        {
            return customTags.Contains(customTag);
        }
    }
}