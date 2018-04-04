function userInfo(user_id) {
    $.ajax({
        url: "/User/LoginPermissions",
        type: "POST",
        data: { user_id: user_id },
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
    }).done(function (data) {
        console.log(data);
        let data_array = new Array();
        for (let c in data.perms)
        {
            let obj = new Object();
            obj.permission = data.perms[c];
            console.log(data.perms[c]);
            data_array.push(obj);
        }
        console.log(data_array);
        let result = data_array;

        // Initialize Example 1
         $('#example1').dataTable({
            destroy: true,
            data: result,
            "processing": true,
            "columns": [
                { "data": "permission" }]
        });


    });
}




function transfertOneCurrency() {
    $.ajax({
        url: "/User/GetWallets",
        type: "POST",
        data: { login: "Alexey" },
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
    }).done(function (data) {
        
        console.log(data);
    });
}