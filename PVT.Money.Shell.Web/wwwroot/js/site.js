function userInfo(id) {
    console.log(id);

    $.ajax({
        url: "/User/LoginPermissions",
        type: "POST",
        data: { id: id },
        contentType: "application/x-www-form-urlencoded",
        dataType: "json",
    }).done(function (data) {
        console.log(data);
        let data_array = new Array();
        for (let c in data.perms)
        {
            let obj = new Object();
            obj.currency = data.perms[c].currency;
            obj.value = data.perms[c].value;
            obj.walletName = data.perms[c].walletName;
            console.log(data.perms[c].currency);
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
                { "data": "currency" },
                { "data": "value" },
                { "data": "walletName" }
            ]
        });


    });
}

function SelectWallet(event) {
    const target = event.target;

    let id = target.getAttribute('data-id');
    let wallet_name = target.innerHTML;
    let selectedWallet = document.getElementById("wallet");
    selectedWallet.innerHTML = wallet_name;

    let secWalletId = document.getElementById("secondWalletId");
    secWalletId.value = id;
    console.log(id);
    console.log(secWalletId);
   
}


function SelectCurrency(curr) {
    console.log(curr);
    const CurrencyDiv = document.getElementById("selCurr");
    const hidCurrencyDiv = document.getElementById("hiddenSelCurr");
    CurrencyDiv.innerHTML = curr;
    hidCurrencyDiv.value = curr;
}


//function transfertOneCurrency() {

//    $.ajax({
//        url: "/User/GetWallets",
//        type: "POST",
//        data: { login: "Alexey" },
//        contentType: "application/x-www-form-urlencoded",
//        dataType: "json",
//    }).done(function (data) {
        
//        console.log(data);
//    });
//}

