function OneCurr(walletId, currency)
{
    class Hello extends React.Component {
        render() {
            return <div>
                    <div className="col-md-6">
                        <input id="MoneyValue" asp-for="" className="form-control" type="text" placeholder="Введите сумму" />
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
                <button onClick={TransfertMoney} className="btn btn-default">Перевести</button>
                </div>;
        }
    }

    function TransfertMoney() {

        let secWalletId = document.getElementById("secondWalletId").value;
        let value = document.getElementById("MoneyValue").value;


        $.ajax({
            url: "/User/TransfertMoney",
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
        let userId = document.getElementById("userID").value;
        
       $.ajax({
            url: "/User/GetWallets",
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

                let list = document.createElement('li');
                let subLi = document.createElement('a');
                list.appendChild(subLi);
                subLi.onclick = SelectWallet;
                subLi.setAttribute("data-id", walletId);
                subLi.innerHTML = walletName;
                arr.push(list);

                WalletUL.appendChild(list);
            }

            
            });
    }

   


    ReactDOM.render(
        <Hello />,
        document.getElementById("content")
    )


   
}

