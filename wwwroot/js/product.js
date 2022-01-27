// collecting hidden values for various values
var currentSessionString = document.getElementById('currentSession').innerHTML;
var currentCartIdString = document.getElementById('currentCartId').innerHTML;
var cartItemCount = document.getElementById('cartItemCount').innerHTML;

var product_order_increase = document.getElementsByClassName('order-count-increase')
for (var i = 0; i < product_order_increase.length; i++) {
    var button = product_order_increase[i];
    button.addEventListener('click', function (event) {
        var button_clicked = event.target.parentElement.children[0].value
        button_clicked++;
        event.target.parentElement.children[0].value = button_clicked;
    })
}

var product_order_decrease = document.getElementsByClassName('order-count-decrease')
for (var i = 0; i < product_order_decrease.length; i++) {
    var button = product_order_decrease[i]
    button.addEventListener('click', function (event) {
        var button_clicked = event.target.parentElement.children[0].value
        if (button_clicked > 1) {
            button_clicked--;
        }
        event.target.parentElement.children[0].value = button_clicked;
    })
}

//
//      * grab ID and Value from document properties for 'added' item
//      * send a post request through ajax to the server to create a cartItem which will relate it to existing card in controller
//      * reset the value of qty to 1

var product_order_add_to_cart = document.getElementsByClassName('cart-add-button')
for (var i = 0; i < product_order_add_to_cart.length; i++) {
    var button = product_order_add_to_cart[i]
    button.addEventListener('click', function (event) {

        //gives us the id of the row we want
        var cart_item_id = String(event.target.parentElement.parentElement.children[3].children[0].children[0].id);
        //gives us the qty of input[type=text]
        var cart_item_qty = String(event.target.parentElement.parentElement.children[3].children[0].children[0].value);

        //something is triggering error here and is returning 0 for all values being sent to the post method. 
        //as a result an error is being thrown in api/cartitems and objects cant be saved into database.
        var data = JSON.stringify({
            "product_id_str": cart_item_id,
            "cart_id_str": currentCartIdString,
            "quantity_str": cart_item_qty,
        });


        $.ajax({
            url: "/api/CartItems/",
            type: "POST",
            contentType: "application/json",
            //contentType: "application/json; charset=UTF-8",
            //dataType: "json",
            data: data,
            success: function (data) {
                console.log("successfully added item");
                alert("Added " + cart_item_qty + " of this item to the cart.");
                location.reload();
            },
            error: function () {
                console.log("error");
            },

        });
        
        event.target.cartItemCount += event.target.parentElement.parentElement.children[3].children[0].children[0].value;
        event.target.parentElement.parentElement.children[3].children[0].children[0].value = 1;
    });
}
