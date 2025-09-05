
using Microsoft.AspNetCore.Components;

namespace CodeSeparationBaseClass.Components.Pages
{
    public class MyCounterBase : ComponentBase
    {
        protected int currentCount = 0;

        protected void IncrementCount()
        {
            currentCount++;
        }
    }
}