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
});