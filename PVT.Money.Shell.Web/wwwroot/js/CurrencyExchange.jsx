let array =
    [
        "first",
        "second",
        "third"
    ]


let anch = React.createElement("ul",
    { "data-id": "Datatest" },
    array.map(list =>
        React.createElement('li', null, list))
)




function currencyExchange(walletId, currency, value)
{
    class Exchange extends React.Component {
        render() {
            return <div>
                <div className="row">
                    <div className="col-lg-4">
                        <div className="panel">
                            <div className="panel-heading">
                                
                                Информация о переводе
            </div>
                            <div className="panel-body">
                <div className="col-sm-6">
                    <input id="MoneyValue" className="form-control" type="text" placeholder="Введите сумму" />
                </div>
                <div className="col-md-6">
                    <div className="dropdown">
                        <a className="dropdown-toggle" href="#" onClick={getWallets(walletId, currency)} data-toggle="dropdown">
                            <small className="text-muted">Выбрать кошелек <b className="caret"></b></small>
                        </a>
                        <ul id="WalletList" className="dropdown-menu animated flipInX m-t-xs">

                        </ul>
                    </div>
                    <div id="wallet"></div>
                </div>
                <br /><br />
                <br />
                <button onClick={ExchangeMoney} className="btn btn-default">Перевести</button>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>;
        }
    }

    function ExchangeMoney() {
     

        let secWalletId = document.getElementById("secondWalletId").value;
        let value = document.getElementById("MoneyValue").value;
        console.log(secWalletId);
        console.log(value);
        debugger;
        $.ajax({
            url: location.origin+"/User/ExchangeMoney",
            type: "POST",
            data: { value: value, firstWalletId: walletId, secondWalletId: secWalletId },
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
            complete: function (e, xhr, settings) {
                location.reload();
                if (e.status === 302) {
                    console.log(e.responseText);
                } else {
                    console.log(e.status);
                }
            }
        });
    }


    function getWallets(walletId, currency) {
        
        console.log(walletId);
        console.log(currency);
        let userId = document.getElementById("userID").value;

        $.ajax({
            url: location.origin+"/User/GetCurrWallets",
            type: "POST",
            data: { walletId: walletId, currency: currency, userID: userId },
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
        }).done(function (data) {
            let WalletUL = document.getElementById("WalletList");
            WalletUL.innerHTML = '';
            console.log(data);
            //let wallets = data.wallet.map(list => list.walletName + " (" + list.currency + ")");


            for (let count in data.wallet) {
                let list = document.createElement('li');
                let subLi = document.createElement('a');
                list.appendChild(subLi);
                subLi.onclick = SelectWallet;
                subLi.setAttribute("data-id", data.wallet[count].walletId);
                subLi.innerHTML = data.wallet[count].walletName + " (" + data.wallet[count].currency + ")";

                WalletUL.appendChild(list);
            }


            
        });

       
    }




    ReactDOM.render(
        <Exchange />,
        document.getElementById("content")
    )
}