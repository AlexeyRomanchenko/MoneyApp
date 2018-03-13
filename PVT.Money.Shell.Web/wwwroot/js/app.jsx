function OneCurr()
{
    class Hello extends React.Component {
        render() {
            return <div>
                <div className="col-md-6">
                    <input className="form-control" type="text" placeholder="Введите сумму" />
                </div>
                <div className="col-md-6">
                <div class="dropdown">
                    <a class="dropdown-toggle" href="#" data-toggle="dropdown">
                        <small class="text-muted">Выбрать кошелек <b class="caret"></b></small>
                    </a>
                    <ul class="dropdown-menu animated flipInX m-t-xs">
                        <li><a href="#">На счет в этой валюте</a></li>
                        <li><a href="#">На счет в другую валюту</a></li>
                    </ul>
                </div>
                </div>
                <br /><br />
                <br />
                <button className="btn btn-default">Перевести</button>
                </div>;
        }
    }
    ReactDOM.render(
        <Hello />,
        document.getElementById("content")
    )
    
}