getDataCategory();
  
function getDataCategory() {
    $.ajax({
        type: 'GET',
        url: apiDomain + '/api/Category/GetCategory',
        contentType: 'application/json',
        data: {
            UserID: localStorage.getItem('userID')
        },
        success: function (response) {
            console.log(response)
            var $table = $("#table");
            $table.find("tr:gt(0)").remove();

            $.each(response, function (index, item) {
                var $newRow = $("<tr></tr>");
                $newRow.append('<td>' + (index + 1) + '.</td>');
                $newRow.append('<td id="CatName_' + (index + 1) + '">' + item.category + '</td>');
                $newRow.append('<td style="display: none;" id="catID_' + (index + 1) + '">' + item.categoryID + '</td>');
                $newRow.append('<td><button id="edit" onclick="editpopup(' + (index + 1) + ')">Edit</button><button id="delete" onclick="deletepopup(' + (index + 1) + ')">Delete</button></td>');
                $table.append($newRow);
            });
            $("#popUpID").hide();
        },
        error: function (error) {
            alert(error);
        }
    });
}

function addcategory(){
    var category = $("#addCategoryInput").val();
    if(category == ""){
        alert('harus diisi!')
        return;
    }

    $.ajax({
        type: 'POST',
        url: apiDomain + '/api/Category/AddCategory',
        contentType: 'application/json',
        data: JSON.stringify({
            userID: localStorage.getItem('userID'),
            category: category
        }), 
        success: function () {
            getDataCategory();
            xbtnadd();
        },
        error: function(){
            alert('add data error');
        }
    })

}

function editpopup(number){
    $("#popupedit").show();
    localStorage.setItem('categoryID', $("#catID_" + number).text());
}

function editcategory(){
    var category = $("#editCategoryInput").val();
    if(category == ""){
        alert('harus diisi!')
        return;
    }

    $.ajax({
        type: 'POST',
        url: apiDomain + '/api/Category/EditCategory',
        contentType: 'application/json',
        data: JSON.stringify({
            userID: localStorage.getItem('userID'),
            categoryID: localStorage.getItem('categoryID'),
            category: category,
            
        }), 
        success: function () {
            localStorage.removeItem('categoryID');
            getDataCategory();
            xbtnedit();
        },
        error: function(){
            alert('edit data error');
        }
    })
}

function deletepopup(number){
    $("#popupdelete").show();
    localStorage.setItem('categoryID', $("#catID_" + number).text());
}

function deletecategory(){
    $.ajax({
    type: 'delete',
        url: apiDomain + '/api/Category/DeleteCategory',
        contentType: 'application/json',
        data: JSON.stringify({
            userID: localStorage.getItem('userID'),
            categoryID: localStorage.getItem('categoryID')
            
        }), 
        success: function () {
            localStorage.removeItem('categoryID');
            getDataCategory();
            xbtndelete();
        },
        error: function(){
            alert('delete data error');
        }
    });
}

