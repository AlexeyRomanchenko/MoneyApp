function userInfo(login) {
    $.ajax({
        url: "/User/LoginPermissions",
        type: "POST",
        data: { login: login},
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
    }).done(function (data) {
        console.log(data.dataArray);

    })
}