/*WebServices*/

function ws_criarGrafo()
{
	var nomeGrafo = $('#nomeGrafo').val();
	
	$.ajax
	({
		type: "POST",
		url: "http://localhost:62822/GrafoWebService/GrafoWSA.asmx/criarGrafo",
		contentType: "application/json; charset=utf-8",
		data: "{nome:'" + nomeGrafo + "'}",
		dataType: "json",
		success:function(data)
				{
					var retorno = $.parseJSON(data.d);
					if(retorno.retorno == "ACK")
					{
						var grafo = retorno.objeto;
						$("#nomeGrafoAberto").html(grafo.nome);
						$("#grafo").css('width', parseInt(grafo.width));
						$("#grafo").css('height', parseInt(grafo.height));
						$("#grafo").html('');
					}
					else
					{
						alert(retorno.mensagem)
					}
				},
		error:	function(data)
				{
					alert(data.retorno);
				}
	});
	
	fecharModal();
}

function ws_abrirGrafo()
{
	var nomeGrafo = $('#nomeGrafo').val();
	
	$.ajax
	({
		type: "POST",
		url: "http://localhost:62822/GrafoWebService/GrafoWSA.asmx/abrirGrafo",
		contentType: "application/json; charset=utf-8",
		data: "{nomeGrafo:'" + nomeGrafo + "'}",
		dataType: "json",
		success:function(data)
				{
					var retorno = $.parseJSON(data.d);
					if(retorno.retorno == "ACK")
					{
						var grafo = retorno.objeto;
						$("#nomeGrafoAberto").html(grafo.nome);
						$("#grafo").css('width', parseInt(grafo.width));
						$("#grafo").css('height', parseInt(grafo.height));
						$("#grafo").html('');
						for(i = 0; i < grafo.vertices.length; i++)
						{
							alert(grafo.vertices[i].idVertice);
						}
						alert(grafo.arestas.length);
					}
					else
					{
						alert(retorno.mensagem)
					}
				},
		error:	function(data)
				{
					alert(data.retorno);
				}
	});
	
	fecharModal();
}