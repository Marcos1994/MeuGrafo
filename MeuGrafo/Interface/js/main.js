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
		//		primeiro parametro = propriedade q ir� ser utilizada
		//		segundo parametro = atribuir valor � propriedade
		//		obs.: se for colocar s� o primeiro, � o mesmo q um get do valor
	});
});