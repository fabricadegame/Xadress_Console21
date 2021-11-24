
namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int colunas, int linhas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[colunas, linhas];
        }

        public Peca peca(int coluna, int linha)
        {
            return pecas[coluna, linha];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.coluna, pos.linha];
        }

        public bool existePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.coluna, pos.linha] = p;
            p.posicao = pos;
        }


        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.coluna, pos.linha] = null;
            return aux;
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.coluna < 0 || pos.coluna >= colunas || pos.linha < 0 || pos.linha >= linhas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
