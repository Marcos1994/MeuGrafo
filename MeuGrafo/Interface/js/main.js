$(document).ready(function()
{
	$('.botao').click(function()
	{
		$("#slide").children('img').attr('src', $(this).attr('src'));
		$("#slide").children('img').attr('alt', $(this).attr('alt'));
		document.getElementById('descricaoSlide').innerHTML = $(this).attr('alt');
		//alert($(this).attr('alt'));
		//alert($("#slide").children('img').attr('src'));
		//.		classe
		//#		ID
		//attr	puxar qq atributo de uma tag html
		//		primeiro parametro = propriedade q irá ser utilizada
		//		segundo parametro = atribuir valor à propriedade
		//		obs.: se for colocar só o primeiro, é o mesmo q um get do valor
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