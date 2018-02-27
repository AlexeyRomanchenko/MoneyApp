function userInfo(login) {
  
    $.ajax({
        url: "/User/LoginPermissions",
        data: { login: login },
        dataType: "json",
        type: 'POST',
        cache: false
    }).done(function (data) {
        console.log(data.dataArray);

        console.log(login);
    })
}