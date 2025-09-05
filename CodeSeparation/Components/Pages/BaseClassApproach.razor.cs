using Microsoft.AspNetCore.Components;
namespace CodeSeparation.Components.Pages
{
    public class BaseClassApproach : ComponentBase
    {
        private int counter = 0;
        private void IncrementCounter()
        {
            counter++;
        }
    }
}