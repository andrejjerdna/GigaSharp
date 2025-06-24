namespace GigaSharp.GigaChat;

public record GigaChatEmbeddingResponse(float[] Embeddings, ResponseEmbeddingMetaInfo? MetaInfo = null);