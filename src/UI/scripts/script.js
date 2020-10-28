var tbody = document.querySelector('table tbody');
var cliente = {};

function Cadastrar() {
	cliente.id = document.querySelector('#id').value;
	cliente.name = document.querySelector('#name').value;
	cliente.phone = document.querySelector('#phone').value;
	cliente.email = document.querySelector('#email').value;
	cliente.comments = document.querySelector('#comments').value;

	console.log(cliente);

	if (cliente.id === undefined || cliente.id == 0)
	{
		salvarClientes('POST', 0, cliente);
	}			
	else
	{
		salvarClientes('PUT', cliente.id, cliente);
	}
	
	LimpaCliente();

	carregaClientes();

	$('#myModal').modal('hide');
}

function LimpaCliente(){
	cliente.id = 0;
	cliente.name = '';
	cliente.phone = '';
	cliente.email = '';
	cliente.comments = '';
}

function NovoCliente() {
	var btnSalvar = document.querySelector('#btnSalvar');	
	var tituloModal = document.querySelector('#tituloModal');
	document.querySelector('#id').value = 0;
	document.querySelector('#name').value = '';
	document.querySelector('#phone').value = '';
	document.querySelector('#email').value = '';
	document.querySelector('#comments').value = '';

	cliente = {};

	btnSalvar.textContent = 'Cadastrar';	

	tituloModal.textContent = 'Cadastrar Cliente';

	$('#myModal').modal('show');
}

function Cancelar() {
	var btnSalvar = document.querySelector('#btnSalvar');	
	var tituloModal = document.querySelector('#tituloModal');
	document.querySelector('#name').value = '';
	document.querySelector('#phone').value = '';
	document.querySelector('#email').value = '';
	document.querySelector('#comments').value = '';

	cliente = {};

	btnSalvar.textContent = 'Cadastrar';	

	tituloModal.textContent = 'Cadastrar Cliente';

	$('#myModal').modal('hide');
}

function carregaClientes() {
	tbody.innerHTML = '';

	var xhr = new XMLHttpRequest();

	xhr.open(`GET`, `https://localhost:44353/api/Client`, true); 

	xhr.onerror = function () {
		console.error('ERRO', xhr.readyState);
	}

	xhr.onreadystatechange = function() {
		if (this.readyState == 4){
			if(this.status == 200) {
				var clientes = JSON.parse(this.responseText);
				for(var indice in clientes){
					adicionaLinha(clientes[indice]);
				}
			}
			else if(this.status == 500){
				var erro = JSON.parse(this.responseText);
				console.log(erro.message);
				console.log(erro.exceptionMessage);
			}
		}		
	}

	xhr.send();	
}

function salvarClientes(metodo, id, corpo) {
	var xhr = new XMLHttpRequest();

	if (id === undefined)
		cliente.id = 0;
	else
		cliente.id = parseInt(cliente.id)

	xhr.open(metodo, `https://localhost:44353/api/Client`, false);
	xhr.setRequestHeader('content-type', 'application/json');
	xhr.send(JSON.stringify(corpo));
}

function excluirCliente(id) {
	var xhr = new XMLHttpRequest();
	xhr.open(`DELETE`, `https://localhost:44353/api/Client/${id}`, false);
	xhr.send();
}

function excluir(cliente) {

	bootbox.confirm({
		message: `Tem certeza que deseja exluir o cliente ${cliente.name}`,
		buttons: {
			confirm: {
				label: 'SIM',
				className: 'btn-success'
			},
			cancel: {
				label: 'NÃO',
				className: 'btn-danger'
			}
		},
		callback: function (result) {
			if(result){	
				excluirCliente(cliente.id);
				carregaClientes();
			}
		}
	});
}

carregaClientes();

function editarCliente(cliente){
	var btnSalvar = document.querySelector('#btnSalvar');	
	var tituloModal = document.querySelector('#tituloModal');
	document.querySelector('#id').value = cliente.id;
	document.querySelector('#name').value = cliente.name;
	document.querySelector('#phone').value = cliente.phone;
	document.querySelector('#email').value = cliente.email;
	document.querySelector('#comments').value = cliente.comments;

	btnSalvar.textContent = 'Salvar';

	tituloModal.textContent = `Editar Cliente ${cliente.name}`;

	cliente = cliente;

	console.log(cliente);
}

function adicionaLinha(cliente) {
	var trow = `<tr>
	<td>${cliente.id}</td>
	<td>${cliente.name}</td>
	<td>${cliente.phone}</td>
	<td>${cliente.email}</td>
	<td>${cliente.comments}</td>
	<td>
	<div class="btn-group" role="group">
	<button class="btn btn-info" data-toggle="modal" data-target="#myModal" onclick='editarCliente(${JSON.stringify(cliente)})'>Editar</button>
	<button class="btn btn-danger" onclick='excluir(${JSON.stringify(cliente)})'>Excluir</button>
	</div>
	</td>
	</tr>`;

	tbody.innerHTML += trow;
}