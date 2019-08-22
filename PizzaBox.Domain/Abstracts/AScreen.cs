namespace PizzaBox.Domain.Abstracts
{
    public abstract class AScreen
    {
        // TUI COMMAND BLOCK
        protected static string _register = "CREATE";
        protected static string _signIn = "LOGIN";
        protected static string _view = "VIEW";
        protected static string _locations = "LOCATIONS";
        protected static string _history = "HISTORY";
        protected static string _select = "SELECT";
        protected static string _makeOrder = "ORDER";
        protected static string _custom = "CUSTOM";
        // need pizza presets
        protected static string _yes = "YES";
        protected static string _no = "NO";
        protected static string _previewOrder = "CHECKOUT";
        protected static string _confirmOrder = "CONFIRM";
        protected static string _goBack = "BACK";
        protected static string _signOut = "LOGOUT";

        // TUI DIRECTION BLOCK
        protected static string _invalidArgument = "The input was incorrect. Please try again.";
        protected static string _intro = "It's Pizza Time! Welcome to the Pizza Mausoleum!\n";
        protected static string _welcome = $"Do you want to sign in (type {_signIn}) or create a new account (type {_register})?";
        protected static string _accountName = "Please type your username: ";
        protected static string _accountPassword = "Please type your password: ";
        protected static string _confirmPassword = "Retype your password to confirm: ";
        protected static string _loginSuccess = "\nYou're all set! There's no time like pizza time!\n";
        protected static string _logoutOption = $"To Sign out of your account, type {_signOut}";
        protected static string _viewLocations = $"To View Pizza Store Locations, type {_view} {_locations}";
        protected static string _selectALocation = $"To pick a store to order from, type {_select} and then the store Address";
        protected static string _locationSuccess = "\nLocation set! P I Z Z A T I M E\n";
        protected static string _choosePizza = $"Make your own pizza? (type {_custom}) OR Pick a specialty? (type the Specialty name):";
        protected static string _chooseCrust = "Pick your crust (type the Crust name):";
        protected static string _chooseSize = "What size pizza? (type the Size)";
        protected static string _chooseToppings = "Select your toppings! No more than 5! (type the Topping name)";
        protected static string _addToCart = $"Continue Shopping? (type {_yes} or {_no})";
        protected static string _checkoutCart = $"Preview your Order? (type {_previewOrder})";
        protected static string _goBackToCart = $"Type {_goBack} to restart your order.";
        protected static string _confirmCartOrder = $"Type {_confirmOrder} to confirm purchase!";
        protected static string _viewOrderHistory = $"To view your past orders, type {_view} {_history}";

        protected string CleanString(string arg)
        {
            var result = "";
            if (arg != null)
            {
                result = arg.Trim().ToUpper();
            }
            return result;
        }

    }
}