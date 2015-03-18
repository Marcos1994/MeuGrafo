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
						$("#nomeGrafoAberto").attr('class', grafo.idGrafo);
						$("#grafo").css('width', parseInt(grafo.width));
						$("#grafo").css('height', parseInt(grafo.height));
						$("#grafo").html('<svg id="arestas" class="elementos" height="300px" width="600px"></svg><svg id="vertices" class="elementos" height="300px" width="600px"></svg>');
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
						$("#nomeGrafoAberto").attr('class', grafo.idGrafo);
						$("#grafo").css('width', parseInt(grafo.width));
						$("#grafo").css('height', parseInt(grafo.height));
						$("#grafo").html('<svg id="arestas" class="elementos" height="300px" width="600px"></svg><svg id="vertices" class="elementos" height="300px" width="600px"></svg>');
						$("#vertices").attr('width', grafo.width);
						$("#vertices").attr('height', grafo.height);
						$("#arestas").attr('width', grafo.width);
						$("#arestas").attr('height', grafo.height);
						for(i = 0; i < grafo.vertices.length; i++)
						{
							desenharVertice(grafo.vertices[i].idVertice,
											grafo.vertices[i].valor,
											grafo.vertices[i].posX,
											grafo.vertices[i].posY,
											grafo.vertices[i].cor);
						}
						for(i = 0; i < grafo.arestas.length; i++)
						{
							desenharAresta(	grafo.arestas[i].idAresta,
											grafo.arestas[i].idOrigem,
											grafo.arestas[i].idDestino,
											grafo.arestas[i].peso);
						}
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