function OneCurr()
{
    class Hello extends React.Component {
        render() {
            return <div>
                <div className="col-md-6">
                    <input className="form-control" type="text" placeholder="Введите сумму" />
                </div>
                <div className="col-md-6">
                    <div className="dropdown">
                        <a className="dropdown-toggle" href="#" onClick={getWallets} data-toggle="dropdown">
                        <small className="text-muted">Выбрать кошелек <b className="caret"></b></small>
                    </a>
                    <ul className="dropdown-menu animated flipInX m-t-xs">                      
                        
                    </ul>
                </div>
                </div>
                <br /><br />
                <br />
                <button className="btn btn-default">Перевести</button>
                </div>;
        }
    }

    function getWallets() {
        $.ajax({
            url: "/User/GetWallets",
            type: "POST",
            data: {login:"Alexey"},
            contentType: "application/x-www-form-urlencoded",
            dataType: "json",
        }).done(function (data) {
            console.log(data);
            });
    }

    ReactDOM.render(
        <Hello />,
        document.getElementById("content")
    )


   
}