/*WebServices*/

function ws_criarGrafo()
{
	var nomeGrafo = $('#nomeGrafo').val();
	
	$.ajax({
		type: "GET",
		url: "http://localhost:62822/GrafoWebService/GrafoWSA.asmx/criarGrafo",
		contentType: "application/json; charset=utf-8",
		data: "{nome:'" + nomeGrafo + "'}",
		dataType: "json",
		success: function(data) { alert("aeee"); },
		error: function(data) { alert(data.retorno); }
	});
	
	fecharModal();
}