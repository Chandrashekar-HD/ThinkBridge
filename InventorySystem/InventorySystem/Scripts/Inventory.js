var fade_out = function () {
    $("#errorMessage").fadeOut().empty();
}

/**
 * @description Add's items to Inventory
 */
function create() {
    $('#errorMessage').text("");
    if ($('#name').val().length == 0 || $('#description').val().length == 0 || $('#price').val().length == 0) {   //input validation
        $('#errorMessage').css('display', "block"); 
        $('#errorMessage').text("Please enter all the feilds");  // setting error Message text
       return;
    }
    else if (parseInt($('#price').val()) <= 0) {   // checking weather price is greater then 0
        $('#errorMessage').css('display', "block");
        $('#errorMessage').text("Price should be greater then 0"); //setting error Message text
        return;
    }
    else
        $('#errorMessage').css('display', "none");

    let inventory = {
        Name: $('#name').val(),
        Description: $('#description').val(),
        Price: $('#price').val(),
    };

    //making ajax call to API
    $.ajax({
        url: '/api/Inventories',
        traditional: true,
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify(inventory) ,
        contentType: 'application/json',
        success: function (data) {
            $('#errorMessage').css('display', "block");
            $('#errorMessage').text("Create sucessfull");  
            clearInputValues();  
            setTimeout(fade_out, 3000);  //displaying Create sucessfull message for 3 seconds
            //appending newly created item to inventory list table
            $('#InventoryList').append('<tr><td>' + data.Name + '</td><td>' + data.Price + '</td><td><a href="/ItemDetail/Detail/' + data.ID+' ">Details</a><button class="btn btn-default" ID=' + data.ID + ' style="margin-left:7px" onclick="removeItemFromList(this.id)"><i class= "material-icons" > delete</i ></button ></td></tr>');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $('#errorMessage').css('display', "block");
            $('#errorMessage').text(XMLHttpRequest.responseText); //setting error Message text
            
        }
    });
}

/** 
 * @description Removes item from the list
 * @param {string} id Id of the item
 */
function removeItemFromList(id) {
    $('#errorMessage').text("");   
    $('#errorMessage').css('display', "none");  //hiding error message 
    $("#InventoryList > tbody tr").empty();   //clearing item list table row's

    //making ajax call to API
    $.ajax({
        url: '/api/Inventories/'+id,
        traditional: true,
        type: 'DELETE',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            refreshItemListTable();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $('#errorMessage').css('display', "block");
            $('#errorMessage').text(XMLHttpRequest.responseText);  //setting error Message text

        }
    });
    
}

/**
 * @description clear's input element Values
 */
function clearInputValues() {
    $('#name').val('');
    $('#description').val('');
    $('#price').val('');
}

/**
 * @description Refresh's item list table
 */
function refreshItemListTable() {
    //making ajax call to API
    $.ajax({
        url: '/api/Inventories',
        traditional: true,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            $.each(data, function (index, value) {
                //appending tr to inventory list table
                $('#InventoryList').append('<tr><td>' + data[index].Name + '</td><td>' + data[index].Price + '</td><td><a href="/ItemDetail/Detail/'+ data[index].ID + ' ">Details</a><button class="btn btn-default" ID=' + data[index].ID + ' style="margin-left:7px" onclick="removeItemFromList(this.id)"><i class= "material-icons" > delete</i ></button ></td></tr>');
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $('#errorMessage').css('display', "block");
            $('#errorMessage').text(XMLHttpRequest.responseText);  //setting error Message text

        }
    });

}