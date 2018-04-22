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

            let wallets = data.wallet.map(list => list.walletName+" ("+list.currency+")");
            let subLi = React.createElement('li',
                null,
                wallets.map(wallets => React.createElement('a', { 'onClick' : SelectWallet  }, wallets)))

            ReactDOM.render(
                subLi,
                document.getElementById('WalletList')
            )
        });

       
    }




    ReactDOM.render(
        <Exchange />,
        document.getElementById("content")
    )
}