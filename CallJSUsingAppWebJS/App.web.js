// Called automatically when Blazor starts up
export function onAfterStarted(blazor) {
    console.log("Blazor started!");

    // Expose JS functions globally for Blazor to call
    window.myFunctions = {
        showAlert: function (message) {
            alert("Message from Blazor: " + message);
        },

        addNumbers: function (a, b) {
            return a + b;
        }
    };
}
/*
Notes:

onAfterStarted runs after the Blazor runtime finishes loading.

We attach functions to window.myFunctions so that Blazor C# can call them.
*/

/*
By default, Blazor automatically detects App.web.js if it’s in the project root and builds it into the app. 
You don’t need to reference it in App.razor.

(If you renamed it, you’d have to add a script reference manually.)
*/

/*
Advantages of App.web.js over <script> in App.razor:

Cleaner separation (no inline <script> clutter).

Runs automatically when Blazor starts.

Recommended for .NET 8+ and especially .NET 9 Blazor Web Apps.
*/