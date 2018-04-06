

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
        //let curr = {};
        //curr.value = document.getElementById("MoneyValue").value;

        //curr.firstWalletId = {};
        //curr.firstWalletId.currency = currency;
        //curr.firstWalletId.walletId = walletId;
        //curr.firstWalletId.value = value;

        //curr.secondWalletId = {};
        //curr.secondWalletId
        
        //console.log(curr);
        //debugger;
        let secWalletId = document.getElementById("secondWalletId").value;
        let value = document.getElementById("MoneyValue").value;


        $.ajax({
            url: "/User/ExchangeMoney",
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
            url: "/User/GetCurrWallets",
            type: "POST",
            data: { walletId: walletId, currency: currency, userID: userId },
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
        }).done(function (data) {
            let wallets = data.wallets;
            let WalletUL = document.getElementById("WalletList");
            WalletUL.innerHTML = '';
            let arr = [];
            for (let count in data.wallet) {
                console.log(data);
                let walletName = data.wallet[count].walletName;
                let walletId = data.wallet[count].walletId;
                let Currency = data.wallet[count].currency;

                let list = document.createElement('li');
                let subLi = document.createElement('a');
                list.appendChild(subLi);
                subLi.onclick = SelectWallet;
                subLi.setAttribute("data-id", walletId);
                subLi.innerHTML = walletName + " (" + Currency+")";
                arr.push(list);

                WalletUL.appendChild(list);
            }


        });


    }


    ReactDOM.render(
        <Exchange />,
        document.getElementById("content")
    )
}