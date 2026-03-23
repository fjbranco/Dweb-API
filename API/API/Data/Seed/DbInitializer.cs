using API.Models;

namespace API.Data.Seed
{
    internal class DbInitializer
    {

        internal static async void Initialize(ApplicationDbContext dbContext)
        {

            /*
             * https://stackoverflow.com/questions/70581816/how-to-seed-data-in-net-core-6-with-entity-framework
             * 
             * https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0#initialize-db-with-test-data
             * https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/data/ef-mvc/intro/samples/5cu/Program.cs
             * https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0300
             */


            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            // var auxiliar
            bool haAdicao = false;




            // Se não houver categories, cria-as
            var categories = Array.Empty<Category>();

            if (!dbContext.Categories.Any())
            {
                categories = [
                   new Category { Name = "Paisagens" },
               new Category { Name = "Faróis" },
               new Category { Name = "Castelos" },
               new Category { Name = "Pontes" }
                //adicionar outras categories
                ];
                await dbContext.Categories.AddRangeAsync(categories);
                haAdicao = true;
            }




            // Se não houver MyUser, cria-os
            var myUsers = Array.Empty<MyUser>();
            if (!dbContext.Clients.Any())
            {
                myUsers = [
                   new MyUser { Name="João Mendes", Address="Rua das Flores, 45", PostalCode="2300-000 TOMAR", Country="Portugal", TaxNumber="123456789", CellPhone="919876543" },
               new MyUser { Name="Maria Sousa", TaxNumber="123459876"  },
               new MyUser { Name="Ana Paula Silva", TaxNumber="123459867", CellPhone="935678921"  }
                  ];
                await dbContext.Clients.AddRangeAsync(myUsers);
                haAdicao = true;
            }



            // Se não houver photos, cria-as
            var photos = Array.Empty<Photography>();
            if (!dbContext.Photos.Any())
            {
                photos = [
                  new Photography{Title="Vale das Rosas, Marrocos", Description="Cerca de 3000 a 4000 toneladas de rosas silvestres são produzidas no Vale das Rosas todos os anos. A roseira de Damasco que cresce neste vale é muito popular devido à sua intensa fragrância. A maior atração da zona é o 'Festival do Vale das Rosas', que inclui deliciosa gastronomia, danças e cantares.", File="AA1291sb.jpg", Date=DateTime.Parse("2021-05-14"), Price=67, Category=categories[0]},
              new Photography{Title="Pando, Utah, EUA", Description="O Pando é o organismo vivo de maiores dimensões conhecido na Terra. O sistema coletivo de raízes destas 40.000 árvores pesa quase 6000 toneladas e ocupa um espaço de cerca de 43 hectares! As caraterísticas únicas deste bosque, fizeram dele um local famoso. As pessoas visitam-no para admirar e viver a experiência do Pando, especialmente, quando as folhas mudam de cor.", File="AA129g7O.jpg", Date=DateTime.Parse("2021-05-13"), Price=166, Category=categories[0] },
              new Photography{Title="Smitswinkel Bay, África do Sul", Description="A praia de Smitswinkel Bay, na Cidade do Cabo, constitui um bom exemplo de um local famoso que é, também, isolado, escondido e relativamente inacessível, proporcionando vistas magníficas do oceano e das montanhas. Nadar, fazer mergulho, pescar e praticar snorkeling são algumas das suas numerosas atrações.", File="AA12ikRt.jpg", Date=DateTime.Parse("2021-10-07"), Price=143, Category=categories[0] },
              new Photography{Title="Minterne Magna, Reino Unido", Description="A deslumbrante vila de Minterne Magna situa-se na linda região de Dorset. Existe uma vasta gama de flores nos jardins de Minterne, incluindo rododendros, narcisos, jacintos-dos-campos, prímulas e cerejeiras orCategoryntais. Aproximadamente metade de todos os jacintos-dos-campos silvestres de todo o mundo ocorrem no Reino Unido, graças, sobretudo, ao clima fresco e húmido do país.", File="AA128ZdE.jpg", Date=DateTime.Parse("2021-09-23"), Price=171, Category=categories[0] },
              new Photography{Title="Os Doze Apóstolos, África do Sul", Description="Os Doze Apóstolos fazem parte do complexo de Table Mountain, situado ao longo do Oceano Atlântico, na costa oeste da Península do Cabo. A cordilheira montanhosa estende-se por 6 quilómetros e distingue-se pelas vistas panorâmicas. Esta longa e bela extensão é bordejada por magníficas formações rochosas graníticas, praias deslumbrantes e uma enorme variedade de restaurantes, clubes e hotéis.", File="AA10b222.jpg", Date=DateTime.Parse("2023-07-02"), Price=177, Category=categories[0] },
              new Photography{Title="Grossglocknerstrasse, Áustria", Description="Também conhecida como a Estrada Alpina de Grossglockner, é a estrada de montanha pavimentada mais elevada da Áustria e recebe o categories da montanha mais alta do país. Esta estrada de 48 quilómetros com 36 curvas em cotovelo apertado percorre uma Countryagem alpina de caraterísticas únicas, incluindo os campos de neve do vasto glaciar, enquanto explora o maior parque nacional da Áustria.", File="AA10aZTc.jpg", Date=DateTime.Parse("2023-03-08"), Price=71, Category=categories[0] },
              new Photography{Title="Campos de canola, Alemanha", Description="Ao conduzir na Alemanha durante a primavera, é impossível não notar estes belos campos ondulantes de colza em flor, uma cultura comum no país. As flores de um amarelo vibrante atraem muitos visitantes às zonas rurais e os tapetes dourados fazem as delícias dos fotógrafos e dos amantes da natureza.", File="AA10kniX.jpg", Date=DateTime.Parse("2024-12-31"), Price=150, Category=categories[0] },
              new Photography{Title="Vale do Tugela, África do Sul", Description="Esta Countryagem mágica situa-se no Parque Nacional de Royal Natal, na província de KwaZulu-Natal. O vale oferece vistas deslumbrantes do sinuoso rio Tugela, que nasce no planalto elevado de Mont-aux-Sources, ergue-se majestosamente como pano de fundo. Os visitantes adoram explorar os trilhos e as cataratas desta reserva, a pé ou a cavalo, desfrutando as vistas mais cativantes do vale.", File="AAXDGOZ.jpg", Date=DateTime.Parse("2023-08-28"), Price=175, Category=categories[0] },
              new Photography{Title="Gasa, Butão", Description="Esta belíssima região, com elevações entre os 1500 e os 4500 metros, constitui o distrito mais setentrional do reino himalaico do Butão. A região é popularmente conhecida pelo 'Snowman Trek', o 'trilho do boneco de neve'. Este distrito montanhoso é habitado por uma pequena população de cerca de 3000 pessoas, a maioria das quais pertence ao povo Layap ⁠— pastores nómadas.", File="AAXD1JB.jpg", Date=DateTime.Parse("2021-02-14"), Price=59, Category=categories[0] },
              new Photography{Title="Vilas de Merina, Madagáscar", Description="Esta linda Countryagem pertence à vila de Merina, localizada a sul de Antananarivo, a capital e a maior cidade de Madagáscar. A vila é habitada pelo povo malgaxe ou das 'terras altas', o maior grupo étnico da ilha. Alguns dos muito produtivos socalcos de arroz e quintas que aqui se encontram foram construídos graças à inovadora infraestrutura de irrigação, fazendo da região uma visão inspiradora.", File="AAWcxwo.jpg", Date=DateTime.Parse("2023-10-04"), Price=78, Category=categories[0] },
              new Photography{Title="Langkawi, Malásia", Description="Ao longo das últimas décadas, Langkawi tornou-se um destino favorito para os turistas amantes da praia de todas as nacionalidades. Langkawi é o categories da ilha principal e do arquipélago mais vasto que a rodeia, composto por cerca de 99 ilhas e ilhéus no Estreito de Malaca.", File="AA1vs0ln.jpg", Date=DateTime.Parse("2022-01-24"), Price=123, Category=categories[1] },
              new Photography{Title="Farol de Galley Head, Irlanda", Description="Erguendo-se bem acima das ondas que rebentam na costa pronunciada de Cork, o Farol de Galley Head é uma maravilha de grande utilidade. Aceso pela primeira vez em 1878, o seu poderoso farol quebrou a frequente escuridão marítima e, em noites claras, podia ser visto a até 16 milhas náuticas, o que o tornava, na altura, o farol mais potente do mundo.", File="AA1sfVvk.jpg", Date=DateTime.Parse("2023-03-04"), Price=146, Category=categories[1] },
              new Photography{Title="Península de Snaefellsnes, Islândia", Description="O farol de Svortuloft situa-se no extremo oeste da península de Snaefellsnes, na Islândia. O farol está localizado na extremidade de um rochedo com 4 quilómetros de extensão. A maioria dos viajantes gosta de visitar este farol espetacular durante o verão, para desfrutar da magnífica vista.", File="AA17doeJ.jpg", Date=DateTime.Parse("2021-12-31"), Price=166, Category=categories[1] },
              new Photography{Title="Happisburgh, Norfolk, Reino Unido", Description="Esta bonita imagem mostra um céu azul brilhante, com nuvens de um branco imaculado semelhantes a bolas de algodão que contrastam com o amarelo e o verde dos campos de colza em Norfolk, Reino Unido. As estradas de um castanho poeirento são o complemento perfeito para as riscas de cor vermelha e branca do farol.", File="AA129g71.jpg", Date=DateTime.Parse("2022-02-14"), Price=176, Category=categories[1] },
              new Photography{Title="Maine, Nova Inglaterra, EUA", Description="Um dos mais antigos e históricos faróis do Maine, Portland Head Light tem muitas histórias para contar. Circundado por vistas deslumbrantes em todos os lados, o farol foi construído e concluído em 1791 sob as ordens de George Washington, com a ajuda de um fundo estabelecido por este. Atualmente, a luz está automatizada e as restantes partes do farol estão ao cuidado da Guarda Costeira dos USA.", File="AA17dAkA.jpg", Date=DateTime.Parse("2022-08-02"), Price=178, Category=categories[1] },
              new Photography{Title="Farol do Cabo Lefkas, Grécia", Description="O cabo Lefkas, também conhecido como cabo Doukato, é um dos locais mais pitorescos da ilha de Lefkada, graças à vista panorâmica e à Countryagem agreste. O farol localiza-se na extremidade do cabo. Entrou ao serviço em 1890 e continuou em funcioCategorynto até à atualidade. Em tempos, existiu um pequeno templo, dedicado ao deus grego Apolo, no local onde hoje se ergue o farol.", File="AA10b1mt.jpg", Date=DateTime.Parse("2022-10-28"), Price=164, Category=categories[1] },
              new Photography{Title="Farol de Baily, Irlanda", Description="Situada na extremidade sudeste da península de Howth, a estrutura atual do farol de Baily foi construída em 1814. É possível observar vistas espetaculares do farol a partir do Howth Summit, situado nas proximidades. Existe um trilho de caminhada ao longo das falésias que proporciona vistas fantásticas da baía de Dublin, da ilha de Dalkey e das montanhas de Wicklow.", File="AAKowXc.jpg", Date=DateTime.Parse("2022-05-27"), Price=198, Category=categories[1] },
              new Photography{Title="Farol de Pilsum, Alemanha", Description="Localizado na costa alemã do Mar do Norte, este farol foi construído no ano de 1891. Controlou a navegação no canal de Emshörn até 1915. Recentemente, a torre vermelha e amarela tornou-se um popular destino turístico, tendo aparecido em vários filmes e anúncios comerciais. ", File="BB1fqr9d.jpg", Date=DateTime.Parse("2020-12-16"), Price=135, Category=categories[1] },
              new Photography{Title="Farol de Cap Spartel, Marrocos", Description="Localizado acima das Grutas de Hércules, a oeste do porto de Tânger, o farol ergue-se à entrada do Estreito de Gibraltar. Esta estrutura imponente é famosa pela sua arquitetura de estilo árabe tradicional.", File="BB19YejK.jpg", Date=DateTime.Parse("2024-05-07"), Price=114, Category=categories[1] },
              new Photography{Title="Farol de Petit Minou, França", Description="O 'Phare du Petit Minou' é um de entre as dezenas de faróis espalhados pela costa escarpada e por vezes tempestuosa da Bretanha e foi erguido em frente ao forte para ajudar a navegação no estreito Goulet de Brest. Vale a pena admirá-lo de todos os ângulos num passeio de barco.", File="AAE8GPV.jpg", Date=DateTime.Parse("2020-02-20"), Price=102, Category=categories[1] },
              new Photography{Title="Castelo de Eltz, Alemanha", Description="A primeira fase da construção do Castelo de Eltz, na região da Renânia-Palatinado, na Alemanha, teve início em 1157 e, desde então, os membros da família Eltz são proprietários do castelo. Uma disputa entre três irmãos em 1268 fez com que a propriedade fosse dividida entre eles, e o castelo continua dividido entre estes três ramos da família: os Rübenachs, os Rodendorfs e os Kempenich.", File="AA1vs0xs.jpg", Date=DateTime.Parse("2020-02-02"), Price=126, Category=categories[2] },
              new Photography{Title="Castelo de Rochlitz, Alemanha", Description="Numa curva do rio Zwickauer Mulde, as águas calmas são um espelho de um exemplo incrivelmente preservado de arquitetura românica. Trata-se do Castelo de Rochlitz, na Saxónia, Alemanha, iniciado no século XI, tendo sido cuidadosamente preservado desde então. Atualmente, quase todo o castelo de Rochlitz é um museu que permite aos visitantes regressar ao seu apogeu cultural medieval.", File="AA1semSD.jpg", Date=DateTime.Parse("2023-05-07"), Price=134, Category=categories[2] },
              new Photography{Title="Castelo de Tarasp, Suíça", Description="Para um castelo brilhar nesta majestosa Countryagem alpina suíça, tem de ser especial. O castelo de Tarasp é um desses destaques. Fundado no século X, o castelo foi ampliado ao longo dos séculos, tornando-se cada vez mais grandioso e impressionante no topo deste afloramento rochoso. Tarasp foi abandonado em 1815 e caiu em ruínas. Tal como outras fortalezas, esta estrutura foi salva por conservacionistas atentos.", File="AA1pkmTg.jpg", Date=DateTime.Parse("2024-02-18"), Price=168, Category=categories[2] },
              new Photography{Title="Castelo de Bobolice, Polónia", Description="Muitas lendas giram em torno desta impressionante fortaleza no sul da Polónia. Construído pela primeira vez no século XIV, o castelo mudou de mãos muitas vezes, como é habitual nos castelos. As verdadeiras fissuras na sua armadura de pedra começaram em 1587, e continuou a degradar-se e era apenas uma ruína melancólica em 1999, altura em que foi lançado um enorme plano de reconstrução. Como se pode ver, o restauro foi um sucesso estrondoso.", File="BB1lURv1.jpg", Date=DateTime.Parse("2023-02-11"), Price=130, Category=categories[2] },
              new Photography{Title="Castelo de Ross, Irlanda", Description="Construído no século XV para o clã O'Donoghue, este castelo nas margens de Lough Leane, no sudoeste da Irlanda, viu vários proprietários chegar e partir. O estilo arquitetónico do Castelo de Ross é puro estilo de defesa: é uma casa-torre e uma torre de menagem, em blocos e robusta, que constituiu uma fortaleza formidável.", File="BB1jiHXz.jpg", Date=DateTime.Parse("2024-05-17"), Price=125, Category=categories[2] },
              new Photography{Title="Castelo de Kilchurn, Escócia", Description="O castelo de Kilchurn é uma fortaleza arruinada que se ergue numa península rochosa no extremo nordeste do Loch Awe. O castelo foi originalmente construído no século XV por Sir Colin Campbell, primeiro Lord of Glenorchy, para servir de base aos Campbells of Glenorchy. O edifício original era constituído por uma torre de cinco andares, com um pátio defendido por um muro exterior, e foi acrescentado no século XVII.", File="AA12gNTy.jpg", Date=DateTime.Parse("2023-12-03"), Price=177, Category=categories[2] },
              new Photography{Title="Castelo de If, França", Description="Esta fortaleza que se ergue sobre uma pequena ilha calcária situada em frente ao porto de Marselha, no sudeste da França, é um monumento histórico mandado construir por Francisco I em 1524. O castelo foi originalmente construído como uma fortaleza naval e, mais tarde, utilizado como uma prisão de estado durante vários séculos. O Castelo de If foi desmilitarizado e abriu ao público em 1890.", File="AAWfpHa.jpg", Date=DateTime.Parse("2023-07-13"), Price=56, Category=categories[2] },
              new Photography{Title="Castelo de Iwakuni, Japão", Description="Este castelo histórico localizado na Prefeitura de Yamaguchi foi originalmente construído em 1608 por Kikkawa Hiroie no Monte Shiroyama. Após a entrada em vigor da lei de Tokugawa 'um castelo por província', o castelo foi desmantelado e uma réplica foi construída em 1962. A torre proporciona uma bela vista da cidade de Iwakuni e expõe um modelo da ponte de Kintaikyo, espadas e armaduras de samurais.", File="AAWeGXW.jpg", Date=DateTime.Parse("2020-01-03"), Price=68, Category=categories[2] },
              new Photography{Title="Dalian, China", Description="O crepúsculo chega a Dalian e, à medida que os carros passam, a ponte da baía de Xinghai adquire uma espécie de beleza absoluta. Os viadutos que vemos aqui alimentam o vão principal da ponte, que atravessa a Baía de Xinghai, canalizando o tráfego através de uma área urbana com mais de 6 milhões de pessoas. Apesar da enorme população, Dalian é conhecida pelos seus espaços verdes abertos, boa qualidade do ar e condições de tráfego aceitáveis.", File="AA1vs447.jpg", Date=DateTime.Parse("2023-03-08"), Price=93, Category=categories[3] },
              new Photography{Title="Ponte de Seri Wawasan, Malásia", Description="Estamos a olhar para uma maravilha da engenharia que se estende pelas margens do Lago Putrajaya. Algumas pessoas descrevem os cabos da Ponte de Seri Wawasan como velas, outras como asas, mas a maioria concorda que o efeito visual é impressionante. Quando o sol se põe, um espetáculo de luzes que ilumina a ponte com cores variadas proporciona uma visão etérea.", File="BB1lUToh.jpg", Date=DateTime.Parse("2020-03-19"), Price=163, Category=categories[3] },
              new Photography{Title="Bosque Nubloso de Monteverde, Costa Rica", Description="Cerca de 10.500 hectares de floresta nublada estão protegidos numa extraordinária reserva natural no norte da Costa Rica. Na maioria dos dias, as pontes suspensas de Monteverde, como a vermelha aqui, levam os visitantes a uma altura suficiente para passear por entre os bancos de nuvens. Toda esta humidade revigorante é ideal para a biodiversidade.", File="BB1lUQX1.jpg", Date=DateTime.Parse("2020-02-02"), Price=100, Category=categories[3] },
              new Photography{Title="Garganta de Schöllenen, Suíça", Description="O poder erosivo da parte superior do rio Reuss esculpe o maciço de Aar na Suíça e abre um espetacular desfiladeiro no granito. A imagem mostra três pontes: a mais distante é a ponte ferroviária com arcos de Schöllenenbahn, que desaparece num túnel. A mais próxima é a 'Terceira Ponte do Diabo', construída em 1958, e logo abaixo está a 'Segunda Ponte do Diabo', Dateda de 1830.", File="BB1jiRez.jpg", Date=DateTime.Parse("2024-11-22"), Price=132, Category=categories[3] },
              new Photography{Title="Ponte de Bastei, Saxónia, Alemanha", Description="Numa visão espantosa, a bela Ponte de Bastei foi construída nas Montanhas de Elba do Parque Nacional da Suíça Saxónica, na Alemanha. Erguendo-se quase 194 metros acima do rio Elba, esta robusta ponte proporciona vistas esplendorosas sobre o vale circundante. Uma ponte de madeira construída em 1824 para ligar os rochedos esteve originalmente no lugar agora ocupado pela ponte de Bastei e constitui uma atração turística há mais de 200 anos!", File="AA17fKb6.jpg", Date=DateTime.Parse("2021-03-06"), Price=76, Category=categories[3] },
              new Photography{Title="Ponte Tsing Ma, Hong Kong", Description="A ponte Tsing Ma é a 16.ª ponte suspensa mais extensa do mundo, permitindo o tráfego rodoviário e ferroviário em dois níveis simultaneamente. A ponte possui 41 metros de largura, com dois tabuleiros e um vão principal de 1377 metros e uma altura de 206 metros. A ponte tem o categories das duas ilhas que liga entre si – Tsing Yi e Ma Wan.", File="AA149WbT.jpg", Date=DateTime.Parse("2021-01-21"), Price=187, Category=categories[3] },
              new Photography{Title="A Ponte dos Nove Arcos, Seri Lanca", Description="Popularmente conhecida como a 'Ponte no céu', esta espetacular ponte entrou em funcioCategorynto no ano de 1921, durante o período de domínio britânico. Constituindo um dos melhores exemplos da construção ferroviária da era colonial no país, esta ponte com 91 metros de extensão e 7,6 metros de largura eleva-se a 24-30 metros de altura e está situada de forma ideal entre as estações ferroviárias de Ella e Demodara.", File="AAU7WFm.jpg", Date=DateTime.Parse("2021-12-15"), Price=126, Category=categories[3] },
              new Photography{Title="Ponte Vasco da Gama, Portugal", Description="Com um comprimento superior a 16 quilómetros sobre o rio Tejo, é uma das mais extensas pontes da Europa e liga as zonas norte e sul de Portugal. A ponte, que abriu ao público em 1998, foi construída por cerca de 3300 pessoas que trabalharam em simultâneo e demorou 18 meses a ficar terminada. O categories foi-lhe atribuído em homenagem ao explorador português Vasco da Gama.", File="AAKof3l.jpg", Date=DateTime.Parse("2024-01-21"), Price=111, Category=categories[3] },
              new Photography{Title="Ponte de Raízes de Ritymmen, Meghalaya, Índia", Description="Aninhada na bela vila de Nongthymmai, esta é uma das famosas pontes de raízes vivas do estado. A ponte tem um comprimento de 30 metros, é construída com raízes vivas de árvores da borracha e atada a palmeiras de areca.", File="BB1fsGhI.jpg", Date=DateTime.Parse("2023-02-18"), Price=152, Category=categories[3] },
              new Photography{Title="Tower Bridge, Londres, Inglaterra", Description="Construída entre 1886 e 1894 sobre o Rio Tamisa, a ponte é uma das atrações turísticas mais emblemáticas de Londres. Tem duas torres em estilo gótico vitoriano ligadas por duas passadeiras horizontais, que têm como propósito suportar as forças das secções em suspensão da ponte. É utilizada por cerca de 40.000 pessoas diariamente.", File="AAG0uvz.jpg", Date=DateTime.Parse("2023-03-04"), Price=163, Category=categories[3] },
              new Photography{Title="Viaduto de Millau, França", Description="Elevando-se sobre a Countryagem cénica, é indiscutivelmente uma das pontes mais bonitas do mundo. A ponte pode até ser facilmente vista do espaço. Este é o Viaduto de Millau, um exemplo perfeito de como a engenharia se encontra com a arte. Erguido sobre o desfiladeiro do Tarn, no sul de França, e com 2.460 metros de comprimento, o Viaduto de Millau é a ponte mais alta do mundo, com uma altura estrutural de 336,4 metros.", File="AA1r0tLE.jpg", Date=DateTime.Parse("2023-06-24"), Price=128, Category=categories[3] }
                   ];
                await dbContext.Photos.AddRangeAsync(photos);
                haAdicao = true;
            }


            try
            {
                if (haAdicao)
                {
                    // tornar persistentes os dados
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

