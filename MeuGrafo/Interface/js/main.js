$(document).ready(function()
{
	$('.botao').click(function()
	{
		$("#slide").children('img').attr('src', $(this).attr('src'));
		$("#slide").children('img').attr('alt', $(this).attr('alt'));
		document.getElementById('descricaoSlide').innerHTML = $(this).attr('alt');
	});
	
	$('#mascara').click(function()
	{
		fecharModal()
	});
});

function abrirModal()
{
	$('#mascara').css('visibility', 'visible');
	$('#modal').css('visibility', 'visible');
}

function fecharModal()
{
	$('#mascara').css('visibility', 'hidden');
	$('#modal').css('visibility', 'hidden');
	$('#modal').html('');
}

function criarGrafo()
{
	abrirModal();
	var html = "";
	html += '<form action="javascript:ws_criarGrafo();">';
	html += 'Nome do Grafo<br/> <input type="text" name="nomeGrafo" id="nomeGrafo"><br>';
	html += '<input type="submit" value="Criar">';
	html += '</form>';
	$('#modal').html(html);
}

function abrirGrafo()
{
	abrirModal();
	var html = "";
	html += '<form action="javascript:ws_abrirGrafo();">';
	html += 'Nome do Grafo<br/> <input type="text" name="nomeGrafo" id="nomeGrafo"><br>';
	html += '<input type="submit" value="abrir">';
	html += '</form>';
	$('#modal').html(html);
}


function colorirGrafo()
{
	ws_colorirGrafo();
}

function desenharVertice(idVertice, valorVertice, posX, posY, cor)
{
	posX -= 15;
	posY -= 15;
	var vertice = $('#vertices').html() + '<circle id="v' + idVertice + '" cx="' + posX + '" cy="' + posY + '" r="10" stroke="black" stroke-width="2" fill="' + cor + '" />'
	$('#vertices').html(vertice);
}

function desenharAresta(idAresta, idOrigem, idDestino, peso)
{
	var xOrigem = $("#v" + idOrigem).attr('cx');
	var xDestino = $("#v" + idDestino).attr('cx');
	var yOrigem = $("#v" + idOrigem).attr('cy');
	var yDestino = $("#v" + idDestino).attr('cy');
	//var aresta = $('#arestas').html() + '<line id="a' + idAresta + '" x1="' + xOrigem + '" y1="' + yOrigem + '" x2="' + xDestino + '" y2="' + yDestino + '" style="stroke:rgb(255,0,0);stroke-width:2" />';
	var aresta = $('#arestas').html() + '<line id="a' + idAresta + '" x1="' + xOrigem + '" y1="' + yOrigem + '" x2="' + xDestino + '" y2="' + yDestino + '" style="stroke:rgb(255,0,0);stroke-width:2" />';
	$('#arestas').html(aresta);
}