class Hello extends React.Component {
    render() {
        return <h1>Привет</h1>;
    }
}
ReactDOM.render(
    <Hello />,
    document.getElementById("content")
)