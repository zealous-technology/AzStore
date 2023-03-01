
function AddToCart(id) {

    $.get("/ShoppingCart/AddToCart?id=" + id, function (data) {

        $("#divShoppingCart").html(data);
    });
}

function RemoveFromCart(id) {

    $.get("/ShoppingCart/RemoveFromCart?id=" + id, function (data) {

        $("#divShoppingCart").html(data);
    });
}